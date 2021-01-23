              context.Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", context.Session("YourFileName")))
              context.Response.ContentType = "text/plain"
    	      context.Response.BinaryWrite(buffer)
    	      context.Response.OutputStream.Write(buffer, 0, buffer.Length)
    	      context.Response.Flush()
    
            End If
    	  End If
    	End If
      End If
    End Sub
    
    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
      Get
          Return False
      End Get
    End Property
    
