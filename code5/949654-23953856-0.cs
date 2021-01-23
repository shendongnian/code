    List<Entity.account> list = new List<Entity.account>();
    
    
                    list = (
    
                        from a in context.EH_PP_TeacherObservations
                        join b in context.accounts on b.id equals a.EH_PP_TeacherAcctId 
                        join c in context.EH_PP_ObserverStatus on Convert.ToGuid(c.EH_PP_AcctId) equals  b.id into c_join
                        from c in c_join.DefaultIfEmpty()
                        where
                          a.EH_PP_TOSRT_TeacherObservationStatusIDEH == new Guid("0B823C51-EEAE-4490-B0EC-C1F0B1206AEB") &&
                          c.EH_PP_O_isObserver == true
                        select new
                        {
                            Name = (b.firstName + " " + b.lastName),
                            EH_PP_ObservationID = a.EH_PP_ObservationID,
                            EH_PP_TE_TeacherEvalID = a.EH_PP_TE_TeacherEvalID,
                            EH_PP_TOT_ObservationStartDateTime = a.EH_PP_TOT_ObservationStartDateTime,
                            EH_PP_TOT_ObservationEndDateTime = a.EH_PP_TOT_ObservationEndDateTime,
                            EH_PP_TOT_Announced = a.EH_PP_TOT_Announced,
                            EH_PP_TOT_ObservationNum = a.EH_PP_TOT_ObservationNum,
                            EH_PP_TeacherAcctId = a.EH_PP_TeacherAcctId,
                            EH_PP_ObserverAcctID = a.EH_PP_ObserverAcctID,
                            EH_PP_TOSRT_TeacherObservationStatusIDEH = a.EH_PP_TOSRT_TeacherObservationStatusIDEH
                        }
    
                        ).ToList<Entity.account>();
