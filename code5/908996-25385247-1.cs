     public Country getCountry(long ipAddress){
                if (file == null) {
                    //throw new IllegalStateException("Database has been closed.");
                    throw new Exception("Database has been closed.");
                }
