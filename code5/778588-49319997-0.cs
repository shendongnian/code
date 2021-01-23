    var UserTemplates = (from xx in VDC.SURVEY_TEMPLATE
                         where xx.USER_ID == userid && xx.IS_ACTIVE == 1
                         select new
                         {
                           xx.TEMPLATE_ID,
                           xx.TEMPLATE_NAME,
    					   CREATED_DATE=SqlFunctions.DateName("day", xx.CREATED_DATE).Trim() + "/" +
            SqlFunctions.StringConvert((double)xx.CREATED_DATE.Value.Month).TrimStart() + "/" +
            SqlFunctions.DateName("year", xx.CREATED_DATE)
    		 }).ToList();
