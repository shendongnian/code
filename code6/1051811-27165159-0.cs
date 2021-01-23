    FB.ui(obj, function (data) {
                $.ajax({
                    type: "GET",
                    dataType: "json",
                    Content-type: "application/json",
                    url: "/Home/finishOrder",
                    data: myjsobject,
                    success: function(data) { alert('success'); }
                });
            });
    public class orderDetails
    {
        public string payment_id { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public int quantity { get; set; }
        public string request_id { get; set; }
        public string status { get; set; }
        public string signed_request { get; set; }
    }
    public ActionResult finishOrder(orderDetails orderDetails)
    {
        SendEmail.sendEmail(orderDetails.amount.ToString());
        return Json(new { Result = "e-mail sent" }, JsonBehavior.AllowGet);
    }
