    try {
        tryStatements
    }
    catch(FaultException<ValidateStatusFault> faultException){ 
        catchStatements
    }
    catch(Exception ex)
    {
      throw new FaultException(ex.Message); 
    }
    finally {
        finallyStatements
    }
