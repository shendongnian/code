    new SelectListItem { Value = "1", Text = "Waiting Invoices", Selected = true}
    List<SelectListItem> InvoiceStatusDD = new List<SelectListItem>();
    InvoiceStatusDD.Add(new SelectListItem { Value = "0", Text = "All Invoices" });
    InvoiceStatusDD.Add(new SelectListItem { Value = "1", Text = "Waiting Invoices", Selected = true});
    InvoiceStatusDD.Add(new SelectListItem { Value = "7", Text = "Client Approved Invoices" });
    
    @Html.DropDownList("InvoiceStatus", InvoiceStatusDD)
