    public class ValuesToBind
    {
        public string ValueToBind { get; set; }
    }
    
    List<ValuesToBind> lstToBind = (
        from ar in yourArray
        select new ValuesToBind
        {
        	ValueToBind = ar
        }).ToList();
    gView.DataSource = lstTobind;
    gView.DataBind();
