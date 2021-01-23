    var tds = from uctd in _context.USR_CUS_TECH_DISC
                   join ac in _context.APP_CODE on new {TECH_DISC = uctd.TECH_DISC }
                            equals new {TECH_DISC = ac.CODE} into APP_CODE_join
                   from ac in APP_CODE_join.DefaultIfEmpty()
                   join asc in _context.APP_SUBCODE on
                         new { TECH_SUB_DISC = uctd.TECH_SUB_DISC } equals
                         new {TECH_SUB_DISC = asc.SUBCODE} into APP_SUBCODE_join
                   from asc in APP_SUBCODE_join.DefaultIfEmpty()
                   where ac.SUBSYSTEM == "CUS" && (ac.TYPE == "TECH_DISC" || ac.TYPE == null) 
                   && (asc.TYPE == "TECH_DISC" || asc.TYPE == null) 
                   && uctd.MASTER_CUSTOMER_ID == CustomerNumber
                   select new TechnicalDisciplines()
                             {
                                 Code = uctd.TECH_DISC,
                                 Name = ac.DESCR,
                                 Cardinality = uctd.PRIMARY_FLAG,
                                 SubdisciplineCode = uctd.TECH_SUB_DISC,
                                 SubdisciplineName = asc.DESCR
                             };
    var result = new TechDisciplines
                 {
                      CustomerNumber = CustomerNumber,
                      TechnicalDisciplines = tds.ToList()
                 };
