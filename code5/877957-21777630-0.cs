    public bool UpdateFees(string id, string code, string desc, DataSet details)
        {
            bool success = false;
            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                {
                    Fees fees = (Fees)Session.Get("EnrollmentSystem.Domain.Fees", Guid.Parse(id));
                    fees.Code = code;
                    fees.Description = desc;
                    if (details.HasChanges())
                    {
                        if (details.HasChanges(DataRowState.Added))
                        {
                            DataSet tempDataSet = details.GetChanges(DataRowState.Added);
                            foreach (DataRow row in tempDataSet.Tables[0].Rows)
                            {
                                FeesLines lines = new FeesLines();
                                lines.Fee = fees;
                                lines.Id = Guid.NewGuid();
                                lines.Description = row["Description"].ToString();
                                lines.Amount = (row["Amount"].ToString() == "") ? 0 : Convert.ToDecimal(row["Amount"].ToString());
                                fees.FeesDetails.Add(lines);
                                Session.Save(lines);
                            }
                        }
                        if (details.HasChanges(DataRowState.Modified))
                        {
                            DataSet editedSet = details.GetChanges(DataRowState.Modified);
                            foreach (DataRow row in editedSet.Tables[0].Rows)
                            {
                                var item = (from f in fees.FeesDetails
                                            where f.Id.Equals(Guid.Parse(row["Id"].ToString()))
                                            select f).SingleOrDefault();
                                if (item != null)
                                {
                                    item.Description = row["Description"].ToString();
                                    item.Amount = Convert.ToDecimal(row["Amount"].ToString());
                                    Session.SaveOrUpdate(item);
                                }
                            }
                        }
                        if (details.HasChanges(DataRowState.Deleted))
                        {
                            DataSet deleted = details.GetChanges(DataRowState.Deleted);
                            for (int row = 0; row < deleted.Tables[0].Rows.Count; row++ )
                            {
                                var item = (from f in fees.FeesDetails
                                            where f.Id.Equals(Guid.Parse(deleted.Tables[0].Rows[row][0, DataRowVersion.Original].ToString()))
                                            select f).SingleOrDefault();
                                if (item != null)
                                {
                                    fees.FeesDetails.Remove(item);
                                }
                            }
                        }
                    }
                    Session.SaveOrUpdate(fees);
                    transaction.Commit();
                    success = transaction.WasCommitted;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return success;
        }
