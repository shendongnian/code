    [Serializable]
    public class TypeA
    {
      public string m_Title { get; set; }
      private TypeB _targetB
      [XmlIgnore]
      public TypeB m_Target 
      {
         get //Do you need that setter?
         {
            if (_targetB == null)
                _targetB = FindTypeB(m_TypeBTargetID);
            return _targetB;
         }
      }
      public Int32 m_TypeBTargetID {get; set;}
    }
