    public abstract class Deck 
    {
      public abstract ICard this[int index]
      {
        get;
        set;
      }
    
      protected void Create(int cardCount);
    }
    
    public sealed class DeckList : Deck
    {
      private List<ICard> m_list;
      public override ICard this[int index] 
      {
        get { return m_list[index]; }
        set { m_list[index] = value; }
      }
      protected override void Create(int cards) 
      {
        m_list = new List<ICard>(cards);
      }
    }
