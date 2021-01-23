    moq
        .Setup(() => WebServiceMethod(It.IsAny<string>(), It.IsAny<int>(), ...))
        .Returns((some, thing, ...) => {
            if (some == webServiceMethodObject.Some || webServiceMethodObject.Some == null) ...
            {
                return webServiceMethodObject.ReturnEnum;
            }
        });
