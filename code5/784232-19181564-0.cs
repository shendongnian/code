    DateTime StartDate = Convert.ToDateTime("08/1/2012");
            DateTime EndDate = Convert.ToDateTime("03/1/2013");
            for (DateTime i = StartDate; i <= EndDate; i = i.AddMonths(1))
            {
                Response.Write(i.ToString("MM") + "/" + i.ToString("yyyy")+"<br />");
            }
