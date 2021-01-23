    [HttpPost]
            public ActionResult Sample(PaymentBillViewModel model)
            {
                if (ModelState.IsValid)
                {
                   var obj=new NewPayment
                   {
                       LstName= model.LstName,
                       Amount=model.Amount,
                       //... cast what else you need
                   }
                }
                return View();
            }
