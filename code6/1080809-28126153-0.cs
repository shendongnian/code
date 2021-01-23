         [WebMethod(EnableSession = true)]
         public static Object CreateCar(Car **record**) {
             try {
                bool addresult = new CarRepo().CreateCar(record);
                return new { Result = "OK" };
                 
            }
            catch (Exception ex) {
                return new { Result = "ERROR", Message = ex.Message };
            }
            
        }
