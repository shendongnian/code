    using System;
    using System.Windows.Forms;
    using org.apache.pdfbox.pdmodel;
    using org.apache.pdfbox.util;
    //The Diagnostics namespace is needed to specify PDF open parameters. More on them later.
    using System.Diagnostics;
    //specify the string you are searching for
    string searchTerm = "golden";
    //I am using a static file path
    string pdfFilePath = @"F:\myFile.pdf";
    //load the document
    PDDocument document = PDDocument.load(pdfFilePath);
    //get the number of pages
    int numberOfPages = document.getNumberOfPages();
    //create an instance of text stripper to get text from pdf document
    PDFTextStripper stripper = new PDFTextStripper();
    //loop through all the pages. We will search page by page
    for (int pageNumber = 1; pageNumber <= numberOfPages; pageNumber++)
    {
        //set the start page
        stripper.setStartPage(pageNumber);
        //set the end page
        stripper.setEndPage(pageNumber);
        //get the text from the page range we set above.
        //in this case we are search one page.
        //I used the ToLower method to make all the text lowercase
        string pdfText = stripper.getText(document).ToLower();
        //just for fun, display the text on each page in a messagebox. My pdf file only has two pages. But this might by annoying to you if you have more.
        MessageBox.Show(pdfText);
        //search the pdfText for the search term
        if (pdfText.Contains(searchTerm))
        {
            //just for fun, display the page number on which we found the search term
            MessageBox.Show("Found the search term at page " + pageNumber);
            //create a process. We will be opening the pdf document to a specific page number
            Process myProcess = new Process();
            //I specified Adobe Acrobat as the program to open
            myProcess.StartInfo.FileName = "Acrobat.exe";
            //see link below for info on PDF document open parameters
            myProcess.StartInfo.Arguments = "/A \"page=" + pageNumber + "=OpenActions\"" + pdfFilePath;
            //Start the process
            myProcess.Start();
            //break out of the loop. we found our search term and we opened the PDF file
            break;
        }
    }
    //close the document we opened.
    document.close();
