    _fnhConfig = Fluently.Configure().Database(
						MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString)							
						).Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataAccess.NHMG.Fluent.Mapping.DBBufferMap>()
						                	.Conventions.Add(
						                		DefaultLazy.Never()
												,DefaultCascade.None()
										===>	,new DateTimeKindLocalTypeConvention()
									    ===>	,new DateTimeKindLocalNullableTypeConvention()
						                	));
