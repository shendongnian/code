    if (guCSRManagerRoleId == Guid.Empty)
    {
    	// Error Something wrong here.. 
    	RaiseUpdateEvent(CCADemoExtension.Resources.LocalResourcesCCADemoExt.RAISEUPDATEVENT_COULDNOTFIND_CSRMGRROLEINCRM_MSG, ProgressPanelItemStatus.Failed);
    	PackageLog.Log("Could not find CSR Manager Role in CRM", System.Diagnostics.TraceEventType.Error);
    	PackageLog.Log("RunUiiSpecificChanges", System.Diagnostics.TraceEventType.Stop);
    	return false;
    }
    // Check to see if they are already associated... 
    if (!IsRoleAssoicatedWithTeam(EscalationTeamId, guCSRManagerRoleId))
    {
    	// Try to assign team. 
    	CrmSvc.CreateEntityAssociation("team", guTeamId, "role", guCSRManagerRoleId, "teamroles_association");
    }
