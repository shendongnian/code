    cr.Add(Restrictions.Gt(
                        Projections.SqlFunction(
                            new SQLFunctionTemplate(NHibernateUtil.Date,
                                                    "DateAdd(Day," + strParamVal + ", ?1)"),NHibernateUtil.Date,
                            Projections.Property("ModifiedDate")),DateTime.Now));
