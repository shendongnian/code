     public IEnumerable<SASF> GetLongReportData(string commSubGp)
        {
            var context = new Entities();
            string myDate = "2014-03-18";
            DateTime date = Convert.ToDateTime(myDate);
            //Create a result in the type you want to return.
            List<SASF> result;
            switch(commSubGp)
            {
                case "F00": //Agriculture
        
                    result = (from a in context.SASF                
                                 where a.RDate == date &&
                                 a.COMM_SGP.CompareTo(commSubGp) <= 0
                                 orderby a.Conmkt, a.MKTTITL descending
                                 select a).ToList();
                    break;
                case "n10": //petroleum
                    result = (from p in context.SASF
                               where p.RDate == date &&
                               p.COMM_SGP == commSubGp
                               orderby p.Conmkt, p.MKTTITL descending
                               select p).ToList();
                    break;
            }
            return result;     
        }
