        static void Main(string[] args)
        {
            // Read a mysql table
            string connectionString = ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command;
            connection.Open();
          
            DataSet set = new DataSet();
            try
            {
                command = connection.CreateCommand();
                //command.CommandText = "select * from toolsite.user limit 5";
                command.CommandText = "select FirstName, LastName, PersonID, City from my_db.Persons limit 5";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(set);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            // Write Sxml Schema
            set.WriteXmlSchema("D:\\file.xsd");
            // Modify schema code 
            FileStream fs = new FileStream("D:\\file.xsd", FileMode.Open);
            XmlSchema schema;
            ValidationEventHandler eventHandler = new ValidationEventHandler(Program.ShowCompileErrors);
            try
            {             
                // Read the schema into an XMLSchema object.
                schema = XmlSchema.Read(fs, eventHandler);
                // Compile the schema.
                schema.Compile(eventHandler);
                
                // Define an XMLSchemaObjectTable to read the schema elements.
                // This schematable will contain a single element named "NewDataSet" according to mySql syntax
                XmlSchemaObjectTable schematable;
                schematable = schema.Elements;
                // Define a QualifiedName to identify the elements.
                XmlQualifiedName qname = new XmlQualifiedName("NewDataSet", "");
             
                XmlSchemaElement singleElement = new XmlSchemaElement();
                XmlSchemaComplexType complextype = new XmlSchemaComplexType();               
                //  See if the XmlSchemaObjectTable has the element.
                if (schematable.Contains(qname))
                {
                    singleElement = (XmlSchemaElement)schematable[qname];
                    
                        if (singleElement.SchemaTypeName.ToString() == "")
                        {
                            complextype = (XmlSchemaComplexType)singleElement.SchemaType;
                            XmlSchemaChoice choice = new XmlSchemaChoice();
                            choice = (XmlSchemaChoice)complextype.Particle;
                            XmlSchemaObjectCollection collection = choice.Items;
                            XmlSchemaObject obj = collection[0];
                            XmlSchemaComplexType complexsubtype = (XmlSchemaComplexType)((XmlSchemaElement)obj).SchemaType;
                                                        
                            XmlSchemaSequence seqelement = new XmlSchemaSequence();
                            seqelement = (XmlSchemaSequence)complexsubtype.Particle;
                            
                            // Remove column here
                            XmlSchemaElement passwordElement = new XmlSchemaElement();
                            passwordElement = (XmlSchemaElement)seqelement.Items[1];
                            seqelement.Items.Remove(passwordElement);
                            // Add any new column here
                            XmlSchemaElement Newelement = new XmlSchemaElement();
                            Newelement.Name = "Country";
                            Newelement.MinOccurs = 0;
                            Newelement.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
                            seqelement.Items.Add(Newelement);
                                                        
                        }
                }
                // Display the schema in the Output window.
                schema.Write(Console.Out);
                Console.ReadLine();
                // Save the modified schema
                StreamWriter strmWrtr = new StreamWriter("D:\\newfile.xsd", false);
                schema.Write(strmWrtr);
                strmWrtr.Close();
            }
            catch (XmlSchemaException schemaEx)
            {
                Console.WriteLine(schemaEx.Message);
            }
            catch (XmlException xmlEx)
            {
                Console.WriteLine(xmlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {                
                fs.Close();
            }
            // Read the modified schema
            // PROBLEM HERE : My schema is modified but my data of table is lost. I want to just modify the columns . 
            //I dont want to lose data
            set.ReadXmlSchema("D:\\newfile.xsd");
            foreach (DataColumn col in set.Tables[0].Columns)
            {
                Console.WriteLine(col.ColumnName + " type : " + col.DataType);
            }
            Console.WriteLine("Total records = " + set.Tables[0].Rows.Count);
            foreach (DataRow row in set.Tables[0].Rows)
            {
                for(int i = 0; i < row.ItemArray.Count(); i++)
                {
                    Console.Write(row.ItemArray[i] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
                       
        public static void ShowCompileErrors(object sender, ValidationEventArgs args)
        {
            Console.WriteLine("ERROR : Validation Error: {0}", args.Message);
        }
    }
