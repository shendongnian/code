    permissions += "permissions.push(["; 
    lbtnSendToApprove.Enabled = CheckPermission(document, project, user, null, eProjectAdminPermission.EditDocument);
					if (!lbtnSendToApprove.Enabled)
					{
						lbtnSendToApprove.OnClientClick = string.Empty;
						permissions += "Base64.encode('0' ) ,";
					}
					else
						permissions += "Base64.encode('1' ) ,";
					lbtnReleaseDocument.Enabled = true;
					permissions += "Base64.encode('1' ) ,";
					lbtnAddSubversion.Enabled = CheckPermission(document, project, user, null, eProjectAdminPermission.EditDocument);
					if (!lbtnAddSubversion.Enabled)
					{
						lbtnAddSubversion.OnClientClick = string.Empty;
						permissions += "Base64.encode('0' ) ,";
					}
					else
						permissions += "Base64.encode('1' ) ,";
					bool attachmentPermission = CheckPermission(document, project, user, null, eProjectAdminPermission.DetermineAttachment);
					if (!attachmentPermission)
					{
						permissions += "Base64.encode('0' ) ]);";
					}
					else
						permissions += "Base64.encode('1' ) ]);";
    ScriptManager.RegisterStartupScript(upDocuments, upDocuments.GetType(),"ContextMenuPermission"+e.Row.RowIndex.ToString(), permissions , true);//set permissions 
