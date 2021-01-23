TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd); 
string[] rtbLines = textRange.Text.Split(Environment.NewLine);
foreach(line in rtbLines)
{
    //do something with line
}
for this specific code, you will need to use the following library 
using System.Windows.Documents;
