		private bool RowMe(string strColumnDelimiter, string strTextQualifier, string strInput, out string[] strSplitOutput, out string strResultMessage)
		{
			  
			string[] retVal = null;
			bool blnResult = false;
			strResultMessage = "";
			  
		
			//---- We need to escape at least some of the most common
			//				special characters for both delimiter & qualifier ----
			switch (strColumnDelimiter) {
				case "|":
					strColumnDelimiter = "\\|";
					break;
				case "\\":
					strColumnDelimiter = "\\\\";
					break;
			}
			switch (strTextQualifier)
			{
				case "\"":
					strTextQualifier = "\\\"";
					break;
			}
			
			//---- Let's have our delimited row splitter regex! ----
			//string strPattern = "^(?:((?:[^,\"]*)|(?:\"[^\"]*\"))){0,1}(?:(?:,(?:((?:[^,\"]*)|(?:\"[^\"]*\")))))*$";
			string strPattern = String.Concat(
												"^"
													,"(?:"
														,"("
															,"(?:[^" + strColumnDelimiter + strTextQualifier +"]*)"
															,"|"
															,"(?:" + strTextQualifier + "[^" + strTextQualifier + "]*" + strTextQualifier + ")"
														,")"
													,"){0,1}"
																//-- note how this second section is the same as the first, but with a leading delimiter...  
																//					the first column will not have a leading comma, and any subsequent ones must
													,"(?:"
														,"(?:"
															, strColumnDelimiter		// << :)
															,"(?:"
																,"("
																	,"(?:[^" + strColumnDelimiter + "\"]*)"
																	,"|"
																	, "(?:" + strTextQualifier + "[^" + strTextQualifier + "]*" + strTextQualifier + ")"
																,")"
															,")"
														,")"
													,"){0,}"
												,"$"
											);
			 
			//---- And do the regex Match-ing ! ----
			System.Text.RegularExpressions.Regex objRegex = new System.Text.RegularExpressions.Regex(strPattern);
			System.Text.RegularExpressions.MatchCollection objMyMatches = objRegex.Matches(strInput);
			//---- So what did we get? ----
			if (objMyMatches.Count != 1) {
				blnResult = false;
				strResultMessage = "--NO-- no overall match";
			}
			else if (objMyMatches[0].Groups.Count != 3) {
				blnResult = false;
				strResultMessage = "--NO-- pattern not correct";
				throw new ApplicationException("ERROR SPLITTING FLAT FILE ROW!  The hardcoded regular expression appears to be broken.  This should not happen!!!  What's up??");
			}
			else {
				int cnt = (1 + objMyMatches[0].Groups[2].Captures.Count);
				
				retVal = new string[cnt];
				retVal[0] = objMyMatches[0].Groups[1].Captures[0].Value;
				for (int i = 0; i < objMyMatches[0].Groups[2].Captures.Count; i++) {
					retVal[i+1] = objMyMatches[0].Groups[2].Captures[i].Value;
				}
				blnResult = true;
				strResultMessage = "SUCCESS";
			}
			strSplitOutput = retVal;
			return blnResult;
		}
