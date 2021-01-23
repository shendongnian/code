    if (entry.State == EntityState.Added)
                        {
                            for (var i = 0; i < entry.CurrentValues.FieldCount; i++)
                            {
                                var propertyName = entry.CurrentValues.DataRecordInfo.FieldMetadata[i].FieldType.Name;
                                if (propertyName == "Id") continue;
                                if (propertyName == "RowVersion") continue;
                                AuditTrails.Add(new AuditTrail
                                                    {
                                                        DomainId = domainId,
                                                        Controller = "",
                                                        Action = entry.State.ToString(),
                                                        EntityType = entityType,
                                                        EntityId = entityId,
                                                        EntityValue = "", //entityValue,
                                                        Property = propertyName,
                                                        Before = "",
                                                        After = entry.CurrentValues[i].ToString(),
                                                    });
                            }
                        }
