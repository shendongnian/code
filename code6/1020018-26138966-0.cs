            if (model.File != null && model.File.ContentLength > 0)
            {
                Byte[] destination1 = new Byte[model.File.ContentLength];
                model.File.InputStream.Position = 0;
                model.File.InputStream.Read(destination1, 0, model.File.ContentLength);
                model.BankSlip = destination1;
                Session["info.file"]= model.File;//storing session.
            }
            else
            {
                //retrieving session
                var myImg1 = Session["info.file"] as HttpPostedFileBase;
                model.File = myImg1;
                Byte[] data=new Byte[myImg1.ContentLength];
                myImg1.InputStream.Position = 0;
                myImg1.InputStream.Read(data, 0, myImg1.ContentLength);
                model.BankSlip = data;
            }
            }
            catch (Exception ex)
            {                   
                DepositControllerLog.ErrorException("DepositController - LocalBank(Post) - AddAttachment(refreshed) - ", ex);
            }
            }
