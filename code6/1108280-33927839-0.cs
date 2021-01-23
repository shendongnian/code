        public IHttpActionResult Get(string Id)
        {
            dbEntities db = new dbdbEntities();
            var record = db.sp_yourStoreProcedure(Id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
