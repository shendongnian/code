    var ds = (from wl in dbEntities.tbl_weblog
              group wl by new
                 {
                     wl.tms_stamp.Value.Year,
                     wl.tms_stamp.Value.Month,
                     wl.tms_stamp.Value.Day,
                     wl.tms_stamp.Value.Hour
                 } into dateGrp
              select new
              {
                  Year = dateGrp.Year,
                  Month= dateGrp.Month,
                  Day= dateGrp.Day,
                  Hour= dateGrp.Hour,
                  HitCount = dateGrp.Count(),
                  TotalKB = dateGrp.Sum(m => m.int_bytes).Value / 1024
              }).ToList();
