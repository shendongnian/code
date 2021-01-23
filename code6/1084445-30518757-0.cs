    public ContentResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);
            var context = new SchedulerDataContext();
            Int64 source_id = Int64.Parse(actionValues["id"]);
            try
            {
                var changedDelEvent = (Delivery)DHXEventsHelper.Bind(typeof(Delivery), actionValues);
                var changedRecEvent = (Recurring)DHXEventsHelper.Bind(typeof(Recurring), actionValues);
                //operations with recurring events require some additional handling
                bool isFinished = deleteRelated(action, changedRecEvent, context);
                if (!isFinished)
                {
                    switch (action.Type)
                    {
                        case DataActionTypes.Insert:
                            context.Recurrings.InsertOnSubmit(changedRecEvent);
                            context.SubmitChanges();
                            break;
                        case DataActionTypes.Delete:
                            changedRecEvent = context.Recurrings.SingleOrDefault(d => d.id == source_id);
                            if (changedRecEvent != null)
                            {
                                context.Recurrings.DeleteOnSubmit(changedRecEvent);
                            }
                            context.SubmitChanges();
                            break;
                        default:// "update"                                        
                            var eventToUpdate = context.Deliveries.SingleOrDefault(d => d.DeliveryID == source_id);
                            DHXEventsHelper.Update(eventToUpdate, changedRecEvent, new List<string> { "id" });
                            if (eventToUpdate != null && eventToUpdate.RouteID != changedRecEvent.id)
                            {
                                var routeToUpdate = context.Routes.SingleOrDefault(d => d.RouteID == changedRecEvent.id);
                                eventToUpdate.Route = routeToUpdate;
                            }
                            context.SubmitChanges();
                            break;
                    }
                    action.TargetId = changedRecEvent.id;
                }
            }
            catch
            {
                action.Type = DataActionTypes.Error;
            }
            return (new AjaxSaveResponse(action));           
        }
