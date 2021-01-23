    using (var aq_pension = new System.Web.UI.WebControls.SqlDataSource())
            {
                aq_pension.ProviderName = "System.Data.OleDb";
                aq_pension.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:/stat_tresor/stat_tresor/stat_tresor/db/stat1.mdb";
                
                aq_pension.UpdateCommand = "UPDATE tableaux1 SET nbre=0, montant_mois=0,total=0 WHERE code <>''";
                aq_pension.Update();
            }
