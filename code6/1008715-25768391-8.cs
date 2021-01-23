    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    public class TestViewModel
    {
        public List<Checkboxes> PaginasConsultadas { get; set; }
        [RequiredIfTrue("IsAtLeastOneSelected")]
        public string ParaQueUsaEstasPag { get; set; }
        //You dont put that on your view. 
        //This is just used with RequiredIfTrue data anotation attribute so the Validator checks for it
        public bool IsAtLeastOneSelected
        {
            get { return PaginasConsultadas.Any(r => r.ValorCheckBox); }
        }
    }
    public class Checkboxes
    {
        //In order to check/uncheck you should use boolean for ValorCheckBox
        public bool ValorCheckBox { set; get; }
        public string NombreCheckBox { set; get; }
    }
