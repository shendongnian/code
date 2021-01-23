            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            
            Response.AddHeader( "Content-Disposition", "attachment; filename=ProposalRequest-" + fileName + ".xslx" );
            Response.BinaryWrite( pck.GetAsByteArray() );
            // myMemoryStream.WriteTo(Response.OutputStream); //works too
            Response.Flush();
            Response.Close();
