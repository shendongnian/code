    FormDataContext db = new FormDataContext();
    [Table(Name = "FormData")]
    public class FormData
    {
            [Column]
            public DateTime Date;
            [Column]
            public int Type;
    }
    
    IEnumerable<FormData> values = document.Descendants("ItemGroupData").Select(t => { 
        return new FormData {
            FormDate = Convert.ToDateTime(t.XPathSelectElement("ItemData[@ItemOID='I_TABLE_MODAL_DATE_TABLE']").Attribute("Value").Value),
            Type = Convert.ToInt32(t.XPathSelectElement("ItemData[@ItemOID='I_TABLE_MODAL_TYPE_TABLE']").Attribute("Value").Value)
        }; 
    });
    
    
    foreach (FormData data in values) {
    	db.Form.InsertOnSubmit(data);
    }
    
    db.SubmitChanges();
