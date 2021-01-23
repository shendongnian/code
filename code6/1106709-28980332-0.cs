       [NoCache]
        public ActionResult GatePassList()
        {
            var dic = this.myModel.GatePassTypeList()
                         as IDictionary<string, IEnumerable<SelectListItem>;
            ViewBag.GatePassTypeList = dic["entrykey"] as List<SelectListItem>;
            return this.View(this.gatePassEntryModel.GetAllGatePasses());
        }
    
        @Html.DropDownList("Mobiledropdown2", ViewBag.GatePassTypeList as SelectList)  
