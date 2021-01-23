    internal static string FullName(this IEdmEntityContainerElement containerElement)
    {
        Debug.Assert(containerElement != null, "containerElement != null");
        return containerElement.Container.Name + "." + containerElement.Name;
    }
