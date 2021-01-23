    private IEnumerable<SelectListItem> GetCode()
        {
            var dbSchoolCodes = new AllSchoolCodes();
            var code = dbSchoolCodes
                        .GetSchools()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.escuelaCode.ToString(),
                                    Text = x.escuelaName
                                });
    
            return code;
        }
