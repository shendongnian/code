    private bool ApplyPatternToOneProfile(ReportProcessorArgs args, DataRow profileRow)
        {
            bool flag = true;
            if (DataRowExtensions.Field<Guid>(profileRow, Sitecore.Cintel.Reporting.Contact.ProfileInfo.Schema.ProfileId.Name) == Guid.Empty)
                flag = false;
            ViewParameters retrievingBestPattern = CustomProcessorViewPatternProfile.GetParametersForRetrievingBestPattern(args, profileRow);
            DataTable dataTable = CustomerIntelligenceManager.ViewProvider.GenerateContactView(retrievingBestPattern).Data.Dataset[retrievingBestPattern.ViewName];
            if (dataTable.Rows != null && dataTable.Rows.Count != 0)
            {
                if (!this.TryFillData<Guid>(profileRow, Sitecore.Cintel.Reporting.Contact.ProfileInfo.Schema.BestMatchedPatternId, dataTable.Rows[0], Sitecore.Cintel.Reporting.Contact.ProfilePatternMatch.Schema.PatternId.Name) || !this.TryFillData<string>(profileRow, Sitecore.Cintel.Reporting.Contact.ProfileInfo.Schema.BestMatchedPatternDisplayName, dataTable.Rows[0], Sitecore.Cintel.Reporting.Contact.ProfilePatternMatch.Schema.PatternDisplayName.Name) || !this.TryFillData<double>(profileRow, Sitecore.Cintel.Reporting.Contact.ProfileInfo.Schema.BestMatchedPatternGravityShare, dataTable.Rows[0], Sitecore.Cintel.Reporting.Contact.ProfilePatternMatch.Schema.PatternGravityShare.Name))
                    flag = false;
            }
            else
            {
                flag = false;
            }
            
            return flag;
        } 
