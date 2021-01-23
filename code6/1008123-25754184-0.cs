    class Multitype: IComparable
    {
       public int? Number { get; set; }
       public string Words {get; set; }
       public int CompareTo(object obj)
       {
           Multitype other = obj as Multitype;
           if (Number != null && other != null && other.Number != null)
           {
               //...
           }
           else
           {
               //...
           }
       }
    }
