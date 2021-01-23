    public delegate T Compute<T,TParameter>(TParameter parameter);
    public sealed class Lazy<T,TParameter>
    {
      private T m_Result;
      private volatile bool m_IsInitialized;
      private object m_SyncRoot = new object();
      private Compute<T,TParameter> m_Compute;
      private TParameter m_Context;
      public Lazy(Compute<T,TParameter> compute, TParameter context)
      {
        if (compute == null)
        {
          throw new ArgumentNullException("compute");
        }
        m_Compute = compute;
        m_Context = context;
      }
      public T Value
      {
        get
        {
          if (!m_IsInitialized)
          {
            lock (m_SyncRoot)
            {
              if (!m_IsInitialized)
              {
                m_Result = m_Compute.Invoke(m_Context);
                m_Compute = null;
                m_Context = default(TParameter);
                m_IsInitialized = true;
              }
            }
          }
          return m_Result;
        }
      }
    }
    class Memory
    {
      static int VeryExpensiveComputationMethod(int key)
      {
        return key;
      }
      private Dictionary<int, Lazy<int,int>> m_Values = new Dictionary<int, Lazy<int,int>>();
      private object m_SyncRoot = new object();
      public int GetData(int key)
      {
        Lazy<int,int> result;
        lock (m_SyncRoot)
        {
          if (!m_Values.TryGetValue(key, out result))
          {
            result = new Lazy<int,int>(VeryExpensiveComputationMethod, key);
            m_Values[key] = result;
          }
        }
        return result.Value;
      }
    }
