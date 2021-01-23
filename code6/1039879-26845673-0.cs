    public class ReportModel
    {
     public List<Top5Record> GetTop5(int branchId)
    {           
       return (from s in context.Salesmen
       where s.branchId == branchId
       select new Top5Record
      {
         Name  = tr.Name,
         Sales = tr.Sales
      }).ToList();
    }
    }
