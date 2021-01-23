    var UserTemplates = (from xx in VDC.SURVEY_TEMPLATE
                     where xx.USER_ID == userid && xx.IS_ACTIVE == 1
                     select new Attributes
                     {
                       TEMPLATE_ID=xx.TEMPLATE_ID,
                       TEMPLATE_NAME=xx.TEMPLATE_NAME,
                       dateCreatd = xx.CREATED_DATE                      
                     })
                     .AsEnumerable()
                     .select(p=>new Attributes
                     {
                       TEMPLATE_ID =p.TEMPLATE_ID,
                       TEMPLATE_NAME=p.TEMPLATE_NAME,
                       dateString = p.dateCreatd .Value.toString("YYYY-MMM-dd")                       
                     }).ToList();
   
    public class Attributes
    {
     public string TEMPLATE_ID { get; set; }
     public string TEMPLATE_NAME { get; set }
     public DateTime dateCreatd { get; set; }
     public string dateString { get; set; }
    }
