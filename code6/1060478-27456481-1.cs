    var caseList = from c in Cases
                       group c by new { c.Year } into yrgrp
                       orderby yrgrp.Key.Year
                       select new
                       {
                           Year = yrgrp.Key.Year,
                           Agencies = from d in yrgrp
                                      group d by new { d.Agency} into agencygrp
                                      select new
                                      {
                                          Agency = agencygrp.Key.Agency,
                                          Total = agencygrp.Count(),
                                          Attorneys = from e in agencygrp
                                                      group e by e.Attorney into attorneygrp
                                                      select new 
                                                      {
                                                         Attorney = attorneygrp.Key,
                                                         Cases = attorneygrp,
                                                         Total = attorneygrp.Count()
                                                      
                                                      }
                                          
                                      }
                       };
