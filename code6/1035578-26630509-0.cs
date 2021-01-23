    // Entitys
    public class Sp  
    {
        public int Id { get; set; }
        public int IdDict { get; set; }
        public Dict Dicts { get; set; }
        public DictCaption { get { return Dicts.Caption; } }
    } 
    public class Dict
    {
        public int Id { get; set; }
        public string Caption { get; set; }
    }
    .... 
    dataGridView.DataSource = dbContext.Set<Sp>().ToList;
    var c = new DataGridViewTextBoxColumn
    {
        DataPropertyName = "DictCaption"  
    }
