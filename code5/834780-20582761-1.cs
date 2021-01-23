      using (var db = new KitRepository<ServiceLevel>())
                {               
                    using (var kit = new KitRepository<Kit>())
                    {
                        var kitServiceLevel = kit.Search(o => o.PatientId == patientId).Select(i => i.kitServiceLevelId).ToList();
                        var temp = db.Where(o => o.HospitalMasterId == HospitalId && kitServiceLevel.Contains(o.ServiceLevelId) && o.IsEnabled == true).Select(i => i.TabletRequired).ToList();
                        var entity = db.Search(l => temp.Contains(l.TabletRequired) && lstServiceType.Contains(l.ServiceCodeTypeEnumId)).ToList();
                                           
                        var model = new List<ServiceLevelModel>();
                        Mapper.Map(entity, model);
                        return model;
                    }
                }
