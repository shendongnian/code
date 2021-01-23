    public ActionResult OrderDel(int id)
        {
            string a = Session["UserSession"].ToString();
            var s = (from test in ob.Order_Details where test.Email_ID_Fk == a && test.Order_ID == id select test).FirstOrDefault();
            s.Status = "Order Cancel By User";
            ob.SaveChanges();
            //foreach(var updter in s)
            //{
            //    updter.Status = "Order Cancel By User";
            //}
            return Json("Sucess", JsonRequestBehavior.AllowGet);
        } <script>
                function Cancel(id) {
                    if (confirm("Are your sure ? Want to Cancel?")) {
                        $.ajax({
                            type: 'POST',
                            url: '@Url.Action("OrderDel", "Home")/' + id,
                            datatype: 'JSON',
                            success: function (Result) {
                                if (Result == "Sucess")
                                {
                                    alert("Your Order has been Canceled..");
                                    window.location.reload();
                                }
                            },
                            error: function (Msgerror) {
                                alert(Msgerror.responseText);
                            }
                        })
                    }
                }
            </script>
