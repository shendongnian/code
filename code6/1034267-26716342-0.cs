	using DocumentFormat.OpenXml.Packaging;
	using DocumentFormat.OpenXml.Wordprocessing;
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Text;
	namespace docxparsing
	{
		class Program
		{
			// ************************************************
			// grab the word style value
			// ************************************************
			static string getWordStyleValue(string x)
			{
				int p = 0;
				p = x.IndexOf("w:pStyle w:val=");
				if ( p == -1 )
				{
					return "";
				}
				p = p + 15;
				StringBuilder sb = new StringBuilder();
				while (true)
				{
					p++;
					char c = x[p];
					if (c != '"')
					{
						sb.Append(c);
					}
					else
					{
						break;
					}
				}
				string s = sb.ToString();
				return s;
			}
			// ************************************************
			// Main
			// ************************************************
			static void Main(string[] args)
			{
				string theFile = @"C:\temp\sample.docx";
				WordprocessingDocument doc =  WordprocessingDocument.Open(theFile,false);
				string body_table     = "DocumentFormat.OpenXml.Wordprocessing.Table";
				string body_paragraph = "DocumentFormat.OpenXml.Wordprocessing.Paragraph";
				Body body = doc.MainDocumentPart.Document.Body;
				StreamWriter sw1 = new StreamWriter("paragraphs.log");
				foreach (var b in body)
				{
					string body_type = b.ToString();
					if (body_type == body_paragraph)
					{
						string str = getWordStyleValue(b.InnerXml);
						if (str == "" || str == "HeadingNon-TOC" || str == "TOC1" || str == "TOC2" || str == "TableofFigures" || str == "AcronymList" )
						{
							continue;
						}
						sw1.WriteLine(str + "," + b.InnerText);
					}
					if ( body_type == body_table )
					{
				 //       sw1.WriteLine("Table:\n{0}",b.InnerText);
					}
				}
				doc.Close();
				sw1.Close();
			}
		}
	}
