    select new
                           {
                               HISTORies.WO,
                               SSes.TITLE,
                               SSes.DESCRIPT,
                               SSCUSTOMs.CUSTNAME,
                               SSes.STAKER,
                               HISTORies.USER,
                               SSes.STATUS,
                               HISTORies.OLDSTATUS,
                               HISTORies.NEWSTATUS,
                               CURRENT_STATUS = StatusTables.Description,
                               OLD_STATUS = StatusTable_1.Description,
                               NEW_STATUS = StatusTable_2.Description,
                               HISTORies.DATE.Value.Month,
                               HISTORies.DATE
                           }
