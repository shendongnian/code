    using System.Collections.Generic;
    using WebApplication1.Models;
    
    namespace WebApplication1
    {
        partial class Report1
        {
            #region Component Designer generated code
            /// <summary>
            /// Required method for telerik Reporting designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
    
                this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
                List<Class1> list = new List<Class1>();
                list.Add(new Class1 { Nom = "Turbang", Prenom = "Yannick", Pays = "Belgium", Ville = "Arlon" });
                list.Add(new Class1 { Nom = "Turbang2", Prenom = "Yannick2", Pays = "Belgium", Ville = "Arlon2" });
    
                this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
                this.objectDataSource1.DataSource = list;
                this.objectDataSource1.DataMember = "Class1";
    
                //Generated code
                //.....
                //.....
                Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
                Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
                Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
                Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
                Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
                Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
