    IEnumerable<SigmaTEK.Web.Models.SchedulerGridModel> tasks = (from appointment in _appointmentRep.Value.Get().Where(a => (a.Start < DbContext.MaxTime && DbContext.MinTime < a.Expiration))
                                                                        join timeApplink in _timelineAppointmentLink.Value.Get().Where(a => a.AppointmentId != Guid.Empty)
                                                                        on appointment.Id equals timeApplink.AppointmentId
                                                                        join timeline in timelineRep.Value.Get().Where(i => timelines.Contains(i.Id))
                                                                        on timeApplink.TimelineId equals timeline.Id
                                                                        join repeater in _appointmentRepeaterRep.Value.Get().Where(repeater => (repeater.Start < DbContext.MaxTime && DbContext.MinTime < repeater.Expiration))
                                                                        on appointment.Id equals repeater.Appointment
                                                                        into repeaters
                                                                        from repeater in repeaters.DefaultIfEmpty()
                                                                        join aInstance in _appointmentInstanceRep.Value.Get()
                                                                        on appointment.Id equals aInstance.Appointment
                                                                        into instances
                                                                        from instance in instances.DefaultIfEmpty()
                                                                        join opRes in opResRep.Get()
                                                                        on instance.ResourceOwner equals opRes.Id
                                                                        into opResources
                                                                        from op in opResources.DefaultIfEmpty()
                                                                        join itemResource in _opDocItemResourcelinkRep.Value.Get()
                                                                        on op.Id equals itemResource.Resource
                                                                        into itemsResources
                                                                        from itemresource in itemsResources.DefaultIfEmpty()
                                                                        join opDocItem in opDocItemRep.Get()
                                                                        on itemresource.OpDocItem equals opDocItem.Id
                                                                        into opDocItems
                                                                        from opdocitem in opDocItems.DefaultIfEmpty()
                                                                        join opDocSection in opDocOpSecRep.Get()
                                                                        on opdocitem.SectionId equals opDocSection.Id
                                                                        into sections
                                                                        from section in sections.DefaultIfEmpty()
                                                                        join opDoc in opDocRep.Get()
                                                                        on section.InternalOperationalDocument equals opDoc.Id
                                                                        into opdocs
                                                                        from opdocitem2 in opDocItems.DefaultIfEmpty()
                                                                        join opDocItemLink in opDocItemStrRep.Get()
                                                                        on opdocitem2.Id equals opDocItemLink.Parent
                                                                        into opDocItemLinks
                                                                        from link in opDocItemLinks.DefaultIfEmpty()
                                                                        join finItem in finItemsRep.Get()
                                                                        on link.Child equals finItem.Id
                                                                        into temp1
                                                                        from rd1 in temp1.DefaultIfEmpty()
                                                                        join sec in finSectionRep.Get()
                                                                        on rd1.SectionId equals sec.Id
                                                                        into opdocsections
                                                                        from finopdocsec in opdocsections.DefaultIfEmpty()
                                                                        join finopdoc in opDocRep.Get().Where(i => i.DocumentType == "Quote")
                                                                         on finopdocsec.InternalOperationalDocument equals finopdoc.Id
                                                                         into finOpdocs
                                                                        from finOpDoc in finOpdocs.DefaultIfEmpty()
                                                                        join entry in entryRep.Get()
                                                                        on rd1.Transaction equals entry.Transaction
                                                                        into entries
                                                                        from entry2 in entries.DefaultIfEmpty()
                                                                        join resproduct in resprosductRep.Get()
                                                                         on entry2.Id equals resproduct.Entry
                                                                         into resproductlinks
                                                                        from resprlink in resproductlinks.DefaultIfEmpty()
                                                                        join res in resRep.Get()
                                                                        on resprlink.Resource equals res.Id
                                                                        into rootResource
                                                                        from finopdoc in finOpdocs.DefaultIfEmpty()
                                                                        join rel in orgDocIndRep.Get().Where(i => (i.Relationship == "OrderedBy"))
                                                                        on finopdoc.Id equals rel.OperationalDocument
                                                                        into orgDocIndLinks
                                                                        from orgopdoclink in orgDocIndLinks.DefaultIfEmpty()
                                                                        join org in orgRep.Get()
                                                                        on orgopdoclink.Organization equals org.Id
                                                                        into toorgs
                                                                        from opdoc in opdocs.DefaultIfEmpty()
                                                                        from rootresource in rootResource.DefaultIfEmpty()
                                                                        from toorg in toorgs.DefaultIfEmpty()
                                                                        select new SigmaTEK.Web.Models.SchedulerGridModel()
                                                                        {
                                                                            Id = appointment.Id,
                                                                            Description = appointment.Description,
                                                                            End = appointment.Expiration,
                                                                            Start = appointment.Start,
                                                                            OperationDisplayId = op.DisplayId,
                                                                            OperationName = op.Name,
                                                                            AppContextId = _appContext.Id,
                                                                            TimelineId = timeline.Id,
                                                                            AssemblyDisplayId = rootresource.DisplayId,
                                                                            //Duration = SigmaTEK.Models.App.Utils.StringHelpers.TimeSpanToString((appointment.Expiration - appointment.Start)),
                                                                            WorkOrder = opdoc.DisplayId,
                                                                            Organization = toorg.Name
                                                                        }).Distinct().ToList();
    //In your UI
    MyGrid.DataSource = tasks;
    MyGrid.DataBind();
