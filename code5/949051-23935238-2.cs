    }
    				catch (Exception ex)
    				{
    				  //Log error;
    				}
    				finally
    				{
    				  doc.Close();
    				}
    
    			}
    			Response.Clear();
    			  //Response.ContentType = "application/pdf";
    			  Response.ContentType = "application/octet-stream";
    			  Response.AddHeader("content-disposition", "attachment;filename= Company " + namefile + ".pdf");
    			  Response.Buffer = true; 
    			  Response.Clear();
    			  var bytes = ms.ToArray();
    			  Response.OutputStream.Write(bytes, 0, bytes.Length);
    			  Response.OutputStream.Flush();
    			
    		}
