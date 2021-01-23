    //ProfileInfo.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    Namespace myWSAT_WAP.Controls
    {
        [Serializable]
        public class Personal
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public DateTime BirthDate { get; set; }
            public string Occupation { get; set; }
            public string Website { get; set; }
        }
    
        [Serializable]
        public class Address
        {
            public string Country { get; set; }
            public string Address1 { get; set; }
            public string AptNumber { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string PostalCode { get; set; }
        }
    
        [Serializable]
        public class Contacts
        {
            public string DayPhone { get; set; }
            public string DayPhoneExt { get; set; }
            public string EveningPhone { get; set; }
            public string EveningPhoneExt { get; set; }
            public string CellPhone { get; set; }
            public string Fax { get; set; }
    
        }
    
        [Serializable]
        public class Company
        {
            public string CompanyName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string PostalCode { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public string Website { get; set; }
    
        }
    
        [Serializable]
        public class Preferences
        {
            public string Culture { get; set; }
            public string Newsletter { get; set; }
    
        }
    
        [Serializable]
        public class ProfileInfo
        {
            public Personal Personal { get; set; }
            public Address Address { get; set; }
            public Contacts Contacts { get; set; }
            public Company Company { get; set; }
            public Preferences Preferences { get; set; }
        }
    }
    
    
    //wProfile.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Profile;
    
    Namespace myWSAT_WAP.Controls
    {
        public class wProfile : ProfileBase
        {
            public ProfileInfo ProfileInfo
            {
                get { return (ProfileInfo)GetPropertyValue("ProfileInfo"); }
            }
    
            public static wProfile GetProfile()
            {
                return (wProfile)HttpContext.Current.Profile;
            }
    
            public static wProfile GetProfile(string userName)
            {
                return (wProfile)Create(userName);
            }
        }
    }
    
    //Web.config
        <profile defaultProvider="MyCMSSqlProfileProvider" automaticSaveEnabled="false" inherits="myWSAT_WAP.controls.wProfile">
          <providers>
            <clear/>
            <add name="MyCMSSqlProfileProvider" connectionStringName="dbMyCMSConnectionString" applicationName="MyCMS" type="System.Web.Profile.SqlProfileProvider"/>
          </providers>
          <properties>
            <group name="Personal">
              <add name="FirstName" type="String"/>
              <add name="LastName" type="String"/>
              <add name="Gender" type="String"/>
              <add name="BirthDate" type="DateTime"/>
              <add name="Occupation" type="String"/>
              <add name="Website" type="String"/>
            </group>
            <group name="Address">
              <add name="Country" type="String"/>
              <add name="Address" type="String"/>
              <add name="AptNumber" type="String"/>
              <add name="City" type="String"/>
              <add name="State" type="String"/>
              <add name="PostalCode" type="String"/>
            </group>
            <group name="Contacts">
              <add name="DayPhone" type="String"/>
              <add name="DayPhoneExt" type="String"/>
              <add name="EveningPhone" type="String"/>
              <add name="EveningPhoneExt" type="String"/>
              <add name="CellPhone" type="String"/>
              <add name="Fax" type="String"/>
            </group>
            <group name="Company">
              <add name="Company" type="String"/>
              <add name="Address" type="String"/>
              <add name="City" type="String"/>
              <add name="State" type="String"/>
              <add name="PostalCode" type="String"/>
              <add name="Phone" type="String"/>
              <add name="Fax" type="String"/>
              <add name="Website" type="String"/>
            </group>
            <group name="Preferences">
              <add name="Culture" type="String" defaultValue="en-US"/>
              <add name="Newsletter" type="String"/>
            </group>
          </properties>
        </profile>
        
    //membership-info.ascx
        #region on page load get current profile
    
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get Profile
            if (!Page.IsPostBack)
            {
                if (Page.User.Identity.IsAuthenticated)
                {
                    // get country names from app_code folder
                    // bind country names to the dropdown list
                    ddlCountries.DataSource = CountryNames.CountryNames.GetCountries();
                    ddlCountries.DataBind();
    
                    // get state names from app_code folder
                    // bind state names to the dropdown lists in address info and company info section
                    ddlStates1.DataSource = UnitedStates.StateNames.GetStates();
                    ddlStates1.DataBind();
                    ddlStates2.DataSource = UnitedStates.StateNames.GetStates();
                    ddlStates2.DataBind();
    
                    // get the selected user's profile based on query string
                    wProfile profile = wProfile.GetProfile();
                    //profileCommon profile = Profile;
    
                    // Subscriptions
                    ddlNewsletter.SelectedValue = profile.GetProfileGroup("Preferences").GetPropertyValue("Newsletter").ToString();
                    //ddlNewsletter.SelectedValue = profile.Preferences.Newsletter;
    
                    // Personal Info
                    txtFirstName.Text = profile.GetProfileGroup("Personal").GetPropertyValue("FirstName").ToString();
                    txtLastName.Text = profile.GetProfileGroup("Personal").GetPropertyValue("LastName").ToString();
                    ddlGenders.SelectedValue = profile.GetProfileGroup("Personal").GetPropertyValue("Gender").ToString();
                    if ((DateTime)profile.GetProfileGroup("Personal").GetPropertyValue("BirthDate") != DateTime.MinValue)
                        txtBirthDate.Text = profile.GetProfileGroup("Personal").GetPropertyValue("BirthDate").ToString();
                    ddlOccupations.SelectedValue = profile.GetProfileGroup("Personal").GetPropertyValue("Occupation").ToString();
                    txtWebsite.Text = profile.GetProfileGroup("Personal").GetPropertyValue("Website").ToString();
    
                    //txtFirstName.Text = profile.Personal.FirstName;
                    //txtLastName.Text = profile.Personal.LastName;
                    //ddlGenders.SelectedValue = profile.Personal.Gender;
                    //if (profile.Personal.BirthDate != DateTime.MinValue)
                    //    txtBirthDate.Text = profile.Personal.BirthDate.ToShortDateString();
                    //ddlOccupations.SelectedValue = profile.Personal.Occupation;
                    //txtWebsite.Text = profile.Personal.Website;
    
                    // Address Info
                    ddlCountries.SelectedValue = profile.GetProfileGroup("Address").GetPropertyValue("Country").ToString();
                    txtAddress.Text = profile.GetProfileGroup("Address").GetPropertyValue("Address").ToString();
                    txtAptNumber.Text = profile.GetProfileGroup("Address").GetPropertyValue("AptNumber").ToString();
                    txtCity.Text = profile.GetProfileGroup("Address").GetPropertyValue("City").ToString();
                    ddlStates1.SelectedValue = profile.GetProfileGroup("Address").GetPropertyValue("State").ToString();
                    txtPostalCode.Text = profile.GetProfileGroup("Address").GetPropertyValue("PostalCode").ToString();
    
                    //ddlCountries.SelectedValue = profile.Address.Country;
                    //txtAddress.Text = profile.Address.Address;
                    //txtAptNumber.Text = profile.Address.AptNumber;
                    //txtCity.Text = profile.Address.City;
                    //ddlStates1.SelectedValue = profile.Company.State;
                    //txtPostalCode.Text = profile.Address.PostalCode;
    
                    // Contact Info
                    txtDayTimePhone.Text = profile.GetProfileGroup("Contacts").GetPropertyValue("DayPhone").ToString();
                    txtDayTimePhoneExt.Text = profile.GetProfileGroup("Contacts").GetPropertyValue("DayPhoneExt").ToString();
                    txtEveningPhone.Text = profile.GetProfileGroup("Contacts").GetPropertyValue("EveningPhone").ToString();
                    txtEveningPhoneExt.Text = profile.GetProfileGroup("Contacts").GetPropertyValue("EveningPhoneExt").ToString();
                    txtCellPhone.Text = profile.GetProfileGroup("Contacts").GetPropertyValue("CellPhone").ToString();
                    txtHomeFax.Text = profile.GetProfileGroup("Contacts").GetPropertyValue("Fax").ToString();
    
                    //txtDayTimePhone.Text = profile.Contacts.DayPhone;
                    //txtDayTimePhoneExt.Text = profile.Contacts.DayPhoneExt;
                    //txtEveningPhone.Text = profile.Contacts.EveningPhone;
                    //txtEveningPhoneExt.Text = profile.Contacts.EveningPhoneExt;
                    //txtCellPhone.Text = profile.Contacts.CellPhone;
                    //txtHomeFax.Text = profile.Contacts.Fax;
    
                    // Company Info
                    txbCompanyName.Text = profile.GetProfileGroup("Company").GetPropertyValue("Company").ToString();
                    txbCompanyAddress.Text = profile.GetProfileGroup("Company").GetPropertyValue("Address").ToString();
                    txbCompanyCity.Text = profile.GetProfileGroup("Company").GetPropertyValue("City").ToString();
                    ddlStates2.SelectedValue = profile.GetProfileGroup("Company").GetPropertyValue("State").ToString();
                    txbCompanyZip.Text = profile.GetProfileGroup("Company").GetPropertyValue("PostalCode").ToString();
                    txbCompanyPhone.Text = profile.GetProfileGroup("Company").GetPropertyValue("Phone").ToString();
                    txbCompanyFax.Text = profile.GetProfileGroup("Company").GetPropertyValue("Fax").ToString();
                    txbCompanyWebsite.Text = profile.GetProfileGroup("Company").GetPropertyValue("Website").ToString();
    
                    //txbCompanyName.Text = profile.Company.Company;
                    //txbCompanyAddress.Text = profile.Company.Address;
                    //txbCompanyCity.Text = profile.Company.City;
                    //ddlStates2.SelectedValue = profile.Company.State;
                    //txbCompanyZip.Text = profile.Company.PostalCode;
                    //txbCompanyPhone.Text = profile.Company.Phone;
                    //txbCompanyFax.Text = profile.Company.Fax;
                    //txbCompanyWebsite.Text = profile.Company.Website;
    
                    // Subscriptions
                    ddlNewsletter.SelectedValue = profile.GetProfileGroup("Preferences").GetPropertyValue("Newsletter").ToString();
    
                    //ddlNewsletter.SelectedValue = profile.Preferences.Newsletter;
                }
            }
        }
    
        #endregion
    
        #region Update current Profile Sub
    
        public void SaveProfile()
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                // get the selected user's profile
                wProfile profile = wProfile.GetProfile();
                //ProfileCommon profile = Profile;
    
                // Personal Info
                profile.GetProfileGroup("Personal").SetPropertyValue("FirstName", txtFirstName.Text);
                profile.GetProfileGroup("Personal").SetPropertyValue("LastName", txtLastName.Text);
                profile.GetProfileGroup("Personal").SetPropertyValue("Gender", ddlGenders.SelectedValue);
                if (txtBirthDate.Text.Trim().Length > 0)
                    profile.GetProfileGroup("Personal").SetPropertyValue("BirthDate", DateTime.Parse(txtBirthDate.Text));
                profile.GetProfileGroup("Personal").SetPropertyValue("Occupation", ddlOccupations.SelectedValue);
                profile.GetProfileGroup("Personal").SetPropertyValue("Website", txtWebsite.Text);
    
                //profile.Personal.FirstName = txtFirstName.Text;
                //profile.Personal.LastName = txtLastName.Text;
                //profile.Personal.Gender = ddlGenders.SelectedValue;
                //if (txtBirthDate.Text.Trim().Length > 0)
                //    profile.Personal.BirthDate = DateTime.Parse(txtBirthDate.Text);
                //profile.Personal.Occupation = ddlOccupations.SelectedValue;
                //profile.Personal.Website = txtWebsite.Text;
    
                // Address Info
                profile.GetProfileGroup("Address").SetPropertyValue("Country", ddlCountries.SelectedValue);
                profile.GetProfileGroup("Address").SetPropertyValue("Address", txtAddress.Text);
                profile.GetProfileGroup("Address").SetPropertyValue("AptNumber", txtAptNumber.Text);
                profile.GetProfileGroup("Address").SetPropertyValue("City", txtCity.Text);
                profile.GetProfileGroup("Address").SetPropertyValue("State", ddlStates1.Text);
                profile.GetProfileGroup("Address").SetPropertyValue("PostalCode", txtPostalCode.Text);
    
                //profile.Address.Country = ddlCountries.SelectedValue;
                //profile.Address.Address = txtAddress.Text;
                //profile.Address.AptNumber = txtAptNumber.Text;
                //profile.Address.City = txtCity.Text;
                //profile.Address.State = ddlStates1.Text;
                //profile.Address.PostalCode = txtPostalCode.Text;
    
                // Contact Info
                profile.GetProfileGroup("Contacts").SetPropertyValue("DayPhone", txtDayTimePhone.Text);
                profile.GetProfileGroup("Contacts").SetPropertyValue("DayPhoneExt", txtDayTimePhoneExt.Text);
                profile.GetProfileGroup("Contacts").SetPropertyValue("EveningPhone", txtEveningPhone.Text);
                profile.GetProfileGroup("Contacts").SetPropertyValue("EveningPhoneExt", txtEveningPhoneExt.Text);
                profile.GetProfileGroup("Contacts").SetPropertyValue("CellPhone", txtCellPhone.Text);
                profile.GetProfileGroup("Contacts").SetPropertyValue("Fax", txtHomeFax.Text);
    
                //profile.Contacts.DayPhone = txtDayTimePhone.Text;
                //profile.Contacts.DayPhoneExt = txtDayTimePhoneExt.Text;
                //profile.Contacts.EveningPhone = txtEveningPhone.Text;
                //profile.Contacts.EveningPhoneExt = txtEveningPhoneExt.Text;
                //profile.Contacts.CellPhone = txtCellPhone.Text;
                //profile.Contacts.Fax = txtHomeFax.Text;
    
                // Company Info
                profile.GetProfileGroup("Company").SetPropertyValue("Company", txbCompanyName.Text);
                profile.GetProfileGroup("Company").SetPropertyValue("Address", txbCompanyAddress.Text);
                profile.GetProfileGroup("Company").SetPropertyValue("City", txbCompanyCity.Text);
                profile.GetProfileGroup("Company").SetPropertyValue("State", ddlStates2.SelectedValue);
                profile.GetProfileGroup("Company").SetPropertyValue("PostalCode", txbCompanyZip.Text);
                profile.GetProfileGroup("Company").SetPropertyValue("Phone", txbCompanyPhone.Text);
                profile.GetProfileGroup("Company").SetPropertyValue("Fax", txbCompanyFax.Text);
                profile.GetProfileGroup("Company").SetPropertyValue("Website", txbCompanyWebsite.Text);
    
                //profile.Company.Company = txbCompanyName.Text;
                //profile.Company.Address = txbCompanyAddress.Text;
                //profile.Company.City = txbCompanyCity.Text;
                //profile.Company.State = ddlStates2.SelectedValue;
                //profile.Company.PostalCode = txbCompanyZip.Text;
                //profile.Company.Phone = txbCompanyPhone.Text;
                //profile.Company.Fax = txbCompanyFax.Text;
                //profile.Company.Website = txbCompanyWebsite.Text;
    
                // Subscriptions
                profile.GetProfileGroup("Preferences").SetPropertyValue("Newsletter", ddlNewsletter.SelectedValue);
    
                //profile.Preferences.Newsletter = ddlNewsletter.SelectedValue;
    
                // this is what we will call from the button click
                // to save the user's profile
                profile.Save();
            }
        }
    
        #endregion
