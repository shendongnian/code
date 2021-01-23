        var query = new UvwRequestAssignmentManagementBO().GetAll().Where(uvw => (uvw.FK_ProcessStep == 2)
            && (uvw.FK_Entity == 1)
            && (uvw.FK_Manager == 15))
            .Select(p => new ReqSupAdminGridVm
            {
                NameFamily = p.NameFamily,
                RequestDate = p.RequestDate,
                RequestNo = p.RequestNo,
                RequestType = GetReqType(p.RequestType),
                RequestEvaluationStatus = GetReqEvalStatus(p.RequestEvaluationStatus_Aggregation),
            });
