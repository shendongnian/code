    public class a_b_relationship 
    {
      public a_b_relationship_id(table_a a, table_b b)
      {
        table_a = a;
        table_b = b;
        ValidTime(20);
      }
      public int a_b_relationship_id { get; set; }
      public int table_a_id { get; set; }
      public int table_b_id { get; set; }
      public DateTime valid_from { get; set; }
      public DateTime valid_to { get; set; }
      public virtual IEnumerable<table_a> table_as { get; set; }
      public virtual IEnumerable<table_b> table_bs { get; set; }
      private void ValidTime(int validMinutes)
      {
        valid_from = DateTime.Now();
        valid_to = DateTime.Now().AddMinutes(validMinutes);
      }
    }
