            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection appSettingSection = (AppSettingsSection)config.GetSection("cbSettings");
            SqlConnection vx130 = new SqlConnection(appSettingSection.Settings[cbRegion.SelectedItem.ToString()].Value);
            SqlDataAdapter da = CreateSQLAdapter(vx130);
            da.Update(tblvAttributes);
        }
