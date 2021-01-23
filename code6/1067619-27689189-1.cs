		using System;
		using System.Collections.Generic;
		using System.IO;
		using System.Linq;
		using System.Text;
		using System.Threading.Tasks;
		using System.Xml;
		using System.Xml.Linq;
		using System.Xml.Xsl;
		namespace StackOverflow
		{
			class Program
			{
				static void Main(string[] args)
				{
					string xslMarkup = @"<?xml version='1.0'?>
		<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
			<xsl:template match='/'>
		<Request>
		   <xsl:for-each select='Request/Points/Point'>
			 <xsl:text disable-output-escaping='yes'>&lt;X</xsl:text>
			  <xsl:value-of select='position()'/>
			   <xsl:text disable-output-escaping='yes'>&gt;</xsl:text>
					<xsl:value-of select='X'/>
			  <xsl:text disable-output-escaping='yes'>&lt;/X</xsl:text>
			  <xsl:value-of select='position()'/>
			   <xsl:text disable-output-escaping='yes'>&gt;</xsl:text>
		  <xsl:text disable-output-escaping='yes'>&lt;Y</xsl:text>
			  <xsl:value-of select='position()'/>
			   <xsl:text disable-output-escaping='yes'>&gt;</xsl:text>
					<xsl:value-of select='Y'/>
			  <xsl:text disable-output-escaping='yes'>&lt;/Y</xsl:text>
			  <xsl:value-of select='position()'/>
			   <xsl:text disable-output-escaping='yes'>&gt;</xsl:text>
			
			
		   </xsl:for-each>
		</Request>
		</xsl:template>
		</xsl:stylesheet>";
					XDocument xmlTree = new XDocument(
						new XElement("Request",
							new XElement("Points",
								new XElement("Point",
									new XElement("X", "5"),
									new XElement("Y", "6")
									),
									 new XElement("Point",
										new XElement("X", "7"),
										new XElement("Y", "8")
										),
										 new XElement("Point",
											new XElement("X", "9"),
											new XElement("Y", "10")
											)
						)
						)
					);
					XDocument newTree = new XDocument();
					using (XmlWriter writer = newTree.CreateWriter())
					{
						// Load the style sheet.
						XslCompiledTransform xslt = new XslCompiledTransform();
						xslt.Load(XmlReader.Create(new StringReader(xslMarkup)));
						// Execute the transform and output the results to a writer.
						xslt.Transform(xmlTree.CreateReader(), writer);
					}
					
					Console.WriteLine(System.Net.WebUtility.HtmlDecode(newTree.ToString()));
				}
			}
		}
