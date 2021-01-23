    public static class DDLHelper
    {
        public static IList<SelectListItem> GetGender()
        {
            IList<SelectListItem> _result = new List<SelectListItem>();
            _result.Add(new SelectListItem { Value = "2", Text = "Male" });
            _result.Add(new SelectListItem { Value = "1", Text = "Female" });
            return _result;
        }
    }
