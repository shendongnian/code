    public class Y_File2Dictionary
        {
            public static Dictionary<string, Y_Variable> File2Dictionary(string fileName)
            {
                // Define delimiters and block comments.
                char[] delimiterChars = { ' ', '\t', '\n', '\r' };
                var blockComments = @"/\*(.*?)\*/";
    
                // Read the file, remove comments, and store in array with no spaces.
                string[] arrayAllVars = Regex
                    .Replace(File.ReadAllText(fileName), blockComments, "",
                        RegexOptions.Singleline)
                    .Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
    
                // Initialize dictionary.
                Dictionary<string, Y_Variable> dictAllVars = new 
                    Dictionary<string, Y_Variable>();
    
                // Loop to read variables and store them in dictionary.
                int i = 0;
                while (i < arrayAllVars.Length)
                {
                    // Read only variables.
                    if (!char.Equals(arrayAllVars[i][0], '/'))
                    {
                        i++;
                        continue;
                    }
    
                    // Read variable name and separate into array
                    // e.g. /YD/YDC/DCSTEC => {"", YD, YDC, DCSTEC}.
                    string[] arrayVarName = Regex.Split(arrayAllVars[i++], "/");
    
                    // Identify variable.
                    string varDb = arrayVarName[2];
                    string varName = arrayVarName[3];
                    string varTyp = (varName[0] == 'D') ? "double" : "integer";
                    int varDim = ((int)Char.GetNumericValue(varName[1]) > 0) ?
                        ((int)Char.GetNumericValue(varName[1])) : 0;
    
                    // Initiallization of variables to store order and size.
                    int varOrder = 0;
                    int[] varSize = new int[3] { 1, 1, 1 };
    
                    // Update order and size, depending on the number of dimensions.
                    switch (varDim)
                    {
                        case 1:
                            varOrder = 1;
                            Int32.TryParse(arrayAllVars[i++], out varSize[0]);
                            varSize[1] = 1;
                            varSize[2] = 1;
                            break;
                        case 2:
                            Int32.TryParse(arrayAllVars[i++], out varOrder);
                            Int32.TryParse(arrayAllVars[i++], out varSize[0]);
                            Int32.TryParse(arrayAllVars[i++], out varSize[1]);
                            varSize[2] = 1;
                            break;
                        case 3:
                            Int32.TryParse(arrayAllVars[i++], out varOrder);
                            Int32.TryParse(arrayAllVars[i++], out varSize[0]);
                            Int32.TryParse(arrayAllVars[i++], out varSize[1]);
                            Int32.TryParse(arrayAllVars[i++], out varSize[2]);
                            break;
                        default:
                            varOrder = 0;
                            varSize[0] = 1;
                            varSize[1] = 1;
                            varSize[2] = 1;
                            break;
                    }
    
                    // Determine total size of variable, get values as strings.
                    var varTotalSize = varSize[0] * varSize[1] * varSize[2];
                    string[] varValStr = new string[varTotalSize];
                    Array.Copy(arrayAllVars, i, varValStr, 0, varTotalSize);
    
                    // Convert values from string to double.
                    double[] varValDbl = new double[varTotalSize];
                    varValDbl = Array.ConvertAll(varValStr, Double.Parse);
    
                    // Add variable to dictionary.
                    if (dictAllVars.ContainsKey(varDb + "_" + varName))
                        dictAllVars.Remove(varDb + "_" + varName);
                    dictAllVars.Add(varDb + "_" + varName, new Y_Variable(varDb, varName,
                        varTyp, varDim, varOrder, varSize, varValDbl));
    
                    i += varTotalSize;
                }
                return dictAllVars;
            }
        }
