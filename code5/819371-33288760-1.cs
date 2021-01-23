    public static NotFoundNegotiatedContentResult NotFound(this ApiController controller, string message)
    {
    	return new NotFoundNegotiatedContentResult(message, controller);
    }
    public static InternalServerErrorNegotiatedContentResult InternalServerError(this ApiController controller, string message)
    {
    	return new InternalServerErrorNegotiatedContentResult(message, controller);
    }
