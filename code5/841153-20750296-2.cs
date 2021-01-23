    <ul>
      <li>ChoiceA</li>
      <li>MenuA
        <ul>
          <li>option 1</li>
          <li>option 2</li>
        </ul>
      </li>
      <li>ChoiceB</li>
      <% if( userIsAuthenticated) { %>
      <li>ChoiceC</li>
      <% } %>
    </ul>
