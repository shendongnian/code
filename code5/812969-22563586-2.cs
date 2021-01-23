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
									string strPattern = String.Concat(
												"^"
													,"(?:"
														,"("
															, "[^\\S" + strColumnDelimiter + strTextQualifier + "]*"		// allow leading whitespace, not counting our delimiter & qualifier
													
															,"(?:"														
																,"(?:[^" + strColumnDelimiter + strTextQualifier +"]*)"			// any amount of characters not colum-delimiter or text-qualifier
																,"|"
																, "(?:" + strTextQualifier + "(?:(?:[^" + strTextQualifier + "])|(?:" + strTextQualifier + strTextQualifier + "))*" + strTextQualifier + ")"		// any amount of characters not text-qualifier OR doubled-text-qualifier inside leading & trailing text-qualifier (allow even colum-delimiter inside text qualifier) 
																,"|"
																,"(?:(?:[^" + strColumnDelimiter + strTextQualifier + "]{1})(?:[^" + strColumnDelimiter + "]*)(?:[^" + strColumnDelimiter + strTextQualifier + "]{1}))"		// any amount of characters not column-delimiter inside other leading & trailing characters not column-delimiter or text-qualifier (allow text-qualifier inside value if it is not leading or trailing)
															,")"
															, "[^\\S" + strColumnDelimiter + strTextQualifier + "]*"		// allow trailing whitespace, not counting our delimiter & qualifier
														,")"
													, "){0,1}"
																//-- note how this second section is almost the same as the first but with a leading delimiter...  
																//					the first column must not have a leading delimiter, and any subsequent ones must
													, "(?:"
														,"(?:"
															, strColumnDelimiter		// << :)
															,"(?:"
																, "("
																	, "[^\\S" + strColumnDelimiter + strTextQualifier + "]*"		// allow leading whitespace, not counting our delimiter & qualifier
																	, "(?:"
																		, "(?:[^" + strColumnDelimiter + strTextQualifier + "]*)"			// any amount of characters not colum-delimiter or text-qualifier
																		, "|"
																		, "(?:" + strTextQualifier + "(?:(?:[^" + strTextQualifier + "])|(?:" + strTextQualifier + strTextQualifier + "))*" + strTextQualifier + ")"		// any amount of characters not text-qualifier OR doubled-text-qualifier inside leading & trailing text-qualifier (allow even colum-delimiter inside text qualifier) 
																		, "|"
																		, "(?:(?:[^" + strColumnDelimiter + strTextQualifier + "]{1})(?:[^" + strColumnDelimiter + "]*)(?:[^" + strColumnDelimiter + strTextQualifier + "]{1}))"		// any amount of characters not column-delimiter inside other leading & trailing characters not column-delimiter or text-qualifier (allow text-qualifier inside value if it is not leading or trailing)
																	, ")"
																	, "[^\\S" + strColumnDelimiter + strTextQualifier + "]*"		// allow trailing whitespace, not counting our delimiter & qualifier
																, ")"
															,")"
														,")"
													, "){0,}"
												,"$"
											);
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
