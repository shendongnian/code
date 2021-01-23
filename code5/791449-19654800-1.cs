    namespace SinsedrixLibrary
    {
    /// <summary>
    /// This source file includes the source code for the 
    /// XmlSettingExpressionBuilder, which is used to handle
    /// declarative expressions based on an XML settings file.
    /// </summary>
    public class ContextualExpressionBuilder : ExpressionBuilder
    {
        public ContextualExpressionBuilder()
        { }
        /// <summary>
        /// This method will be called during page execution
        /// to get the expression that is going to be executed 
        /// to return the value of the declarative expression
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="parsedData"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            // Get a reference to this class since we are going to
            // execute a method on this class that will evaluate
            // the required expression
            CodeTypeReferenceExpression thisType = new CodeTypeReferenceExpression(base.GetType());
            // Create a new expression based on the KEY specified
            // in the declarative expression, this will be used
            // as an input to the method that will evaluate the 
            // required expression
            CodePrimitiveExpression expression = new CodePrimitiveExpression(entry.Expression.Trim().ToString());
			string l_resxPath = Path.GetDirectoryName(context.VirtualPath) + "\\App_LocalResources\\"+ Path.GetFileName(context.VirtualPath);
			CodePrimitiveExpression resxPath = new CodePrimitiveExpression(l_resxPath);
            // The static method name that will evaluate the
            // expression, by accessing the XML file and retreiving
            // the value that corresponds to the key specified
            string evaluationMethod = "GetContextResource";
            // Finally, return the expression that will invoke the method
            // responsible for evaluating the expression
            // The CodeMethodInvokeExpression takes as input the type on which to execute the method specified,
            // the method name, and the array of CodeExpression, which represents the parameters of the method called
			return new CodeMethodInvokeExpression(thisType, evaluationMethod, new CodeExpression[] { expression, resxPath });
        }
        /// <summary>
        /// Evaluates the expression by accessing the XMLSettings file
        /// and retrieve the value corresponding to the key specified in
        /// the input expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
		public static string GetContextResource(string expression, string resxPath)
        {
            // Get the XML Setting file from the application cache if present
			CultureInfo ci = CultureInfo.CurrentCulture;
			string resxKey = resxPath + "." + ci.TwoLetterISOLanguageName;
			XmlDocument xmlSettingDoc = (XmlDocument)HostingEnvironment.Cache[resxKey];
            // check if there was an already loaded document
            if (xmlSettingDoc == null)
            {
                // Define the document here
                xmlSettingDoc = new XmlDocument();
                // Get the config file path using the HostingEnvironment
                // which gives information for application-specific
				string resxCultureFile = resxKey + ".resx";
				string resxDefaultFile = resxPath + ".resx";
				string resxFile = "";
				try
				{
					resxFile = HostingEnvironment.MapPath(resxCultureFile);
				}
				catch(Exception) {
					resxFile = HostingEnvironment.MapPath(resxDefaultFile);
				}
                // Load the XML file into the XmlDocument
                xmlSettingDoc.Load(resxFile);
                // Create a new file dependency to be used when we add the XmlDocument
                // into the Cache, so that when the XmlSettings file change, the Cache will
                // be invalid.
                CacheDependency settingsDepend = new CacheDependency(resxFile);
                // Add the Xmldocument to the Cache
                HostingEnvironment.Cache.Insert(resxKey, xmlSettingDoc, settingsDepend);
            }
			string ctx = ConfigurationManager.AppSettings["ApplicativeContext"];
            // XPATH key used to retrieve the record needed in the form of add[@key='keyvalue']
			string getXPATHKey = String.Format("//data[@name='{0}_{1}']/value", ctx, expression);
            // Search for that record
            XmlNode wantedRecord = xmlSettingDoc.SelectSingleNode(getXPATHKey);
            // If the record exists, return the value property
            if (wantedRecord != null)
				return wantedRecord.InnerText;
			
            // return a message informing users that the expression failed to
            // evaluate to a real value
            return string.Format("Unable to Process Expression : '{0}'", expression);
        }
    }
    }
