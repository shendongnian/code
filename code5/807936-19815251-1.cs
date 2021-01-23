            db.AlterTable(tb => tb
                                    .Named("Users")
                                    .AddColumn(column => column
                                                             .Named("age")
                                                             .Integer
                                    )
                                    .AddColumn(column => column
                                                             .Named("username")
                                                             .Varchar
                                    )
