    public class ParentForm
    {
    public BindingList<xml.Table> table = new BindingList<xml.Table>();
    }
    
    public class ChildForm
    {
    ParentForm localPf;
    pulic ChildForm(ParentForm pf)
    {
    localPf = pf;
    }
    dataGridView4.DataSource = localPf.table;
    }
