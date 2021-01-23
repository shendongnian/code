c#
void AddToEnvironmentVariable(string variable, string newValue, EnvironmentVariableTarget target)
{
    var content = Environment.GetEnvironmentVariable(variable, target) ?? string.Empty;
    if (content.Contains(newValue))
        return;
    var varBuilder = new StringBuilder(content);
    if (content != string.Empty && !content.EndsWith(';'))
        varBuilder.Append(";");
    varBuilder.Append(newValue);
    var finalValue = varBuilder.ToString();
    Environment.SetEnvironmentVariable(variable, finalValue, EnvironmentVariableTarget.Process);
    if (target != EnvironmentVariableTarget.Process)
        Environment.SetEnvironmentVariable(variable, finalValue, target);
}
It handles proper appending using `;` and also ensures that subsequent calls to `GetEnvironmentVariable` contain the added value by setting in with the `Process`target. 
